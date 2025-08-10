<script setup>
import PromptInput from './components/PromptInput/PromptInput.vue';
import SideBar from './components/SideBar/SideBar.vue';
import TextEditor from './components/TextEditor/TextEditor.vue';
import SearchPromptPopup from './components/SearchPromptPopup.vue';
import { onMounted, ref } from 'vue';
import axios from 'axios';

const promptInputVisible = ref(true);
const promptList = ref([]);
const currentPrompt = ref({}); // Dirty fix to hold the current prompt data
const searchedPrompts = ref([]); // Holds the prompts found by search
const searchPromptPopupVisible = ref(false);
const aiGeneratedPrompts = ref([]);

// Function to toggle the visibility of the PromptInput component
const togglePromptInput = () => {
  promptInputVisible.value = !promptInputVisible.value;
};

// Function to handle the search prompt action
const toggleSearchPromptPopup = () => {
  searchPromptPopupVisible.value = !searchPromptPopupVisible.value;
  searchedPrompts.value = promptList.value; // Reset search results to all prompts
};

// Function to handle the prompt submission from PromptInput
const handlePromptSubmitted = async (submittedPrompt) => {
  try {
    // Create the new prompt
    const _ = await axios.post('http://localhost:5221/api/promptentries', {
      prompt: submittedPrompt,
      text: '',
    });

    console.log('Prompt successfully saved to DB');

    await fetchPrompts(); // Refresh the prompt list

    // Find the newly added prompt from the list (latest by name match)
    const newPrompt = promptList.value.find(p => p.prompt === submittedPrompt);
    if (newPrompt && newPrompt.id) {
      await fetchCurrentPrompt(newPrompt.id);
    } else {
      console.warn('Could not find newly added prompt in promptList');
    }

    togglePromptInput();
  } catch (error) {
    console.error('Failed to save or fetch new prompt:', error);
  }
};

// Function to fetch the list of prompts from the backend
const fetchPrompts = async () => {
  try {
    const response = await axios.get('http://localhost:5221/api/promptentries/names');
    promptList.value = response.data;
    console.log('Loaded prompts:', promptList.value);
  } catch (error) {
    console.error('Failed to fetch prompts:', error);
  }
};

// Delete prompt given its ID:
const deletePrompt = async (promptId) => {
  try {
    await axios.delete(`http://localhost:5221/api/promptentries/${promptId}`);
    console.log('Prompt deleted:', promptId);
    await fetchPrompts();
  } catch (error) {
    console.error('Failed to delete prompt:', error);
  }
};

// Update prompt text in the database
const updatePrompt = async (prompt, text) => {
  try {
    await axios.put(`http://localhost:5221/api/promptentries/${prompt.id}`, {
      Prompt: prompt.prompt,
      Text: text
    });
    console.log('Prompt updated:', prompt.id);
    await fetchPrompts();
  } catch (error) {
    console.error('Failed to update prompt:', error);
  }
};

const fetchCurrentPrompt = async (promptId) => {
  try {
    const response = await axios.get(`http://localhost:5221/api/promptentries/${promptId}`);
    currentPrompt.value = response.data;
    console.log('Current prompt fetched:', currentPrompt.value);
  } catch (error) {
    console.error('Failed to fetch current prompt:', error);
  }
};

const handleSelectPrompt = async (item) => {
  if (typeof item === 'object' && item.id) {
    await fetchCurrentPrompt(item.id);
  } else if (typeof item === 'number') {
    await fetchCurrentPrompt(promptList.value[item].id);
  } else {
    console.warn('Invalid prompt selection:', item);
  }
};

const searchPrompts = async (searchTerm) => {
  try {
    if (!searchTerm) {
      searchedPrompts.value = promptList.value; // Reset to all prompts if search term is empty
      return;
    }
    const response = await axios.get(`http://localhost:5221/api/promptentries/search`, {
      params: { prompt: searchTerm }
    });
    searchedPrompts.value = response.data;
    console.log('Search results:', searchedPrompts.value);
  } catch (error) {
    console.error('Failed to search prompts:', error);
  }
};

const generateAIPrompts = async (currentPrompts) => {
  aiGeneratedPrompts.value = [];
  console.log('Generating AI prompts with current prompts:', currentPrompts, " and existing prompts:", promptList.value);
  try {
    const response = await axios.post('http://localhost:5222/api/openai/ai-prompts', {
      currentPrompts,
      existingPrompts: promptList.value
    });
    aiGeneratedPrompts.value = response.data;
    console.log('AI-generated prompts fetched:', aiGeneratedPrompts.value);
  } catch (error) {
    console.error('Failed to fetch AI-generated prompts:', error);
  }
};


onMounted(async () => {
  // Get the list of prompts from the backend
  await fetchPrompts();

  console.log('App mounted, prompts fetched:', promptList.value);
});
</script>

<template>
  <div class="app">
    <SideBar
      :promptList="promptList" 
      :current-prompt="currentPrompt" 
      @delete-prompt="deletePrompt" 
      @select-prompt="handleSelectPrompt" 
      @new-prompt="togglePromptInput"
      @search-prompt="toggleSearchPromptPopup"
    />

    <TextEditor :prompt="currentPrompt" @save-text="updatePrompt" />

    <PromptInput
      v-if="promptInputVisible == true" 
      @prompt-submitted="handlePromptSubmitted" 
      @close-input="togglePromptInput" 
      @fetch-ai-prompts="generateAIPrompts"
      @regenerate-prompts="generateAIPrompts"
      :aiGeneratedPrompts="aiGeneratedPrompts"
    />

    <SearchPromptPopup
      :searchedPrompts="searchedPrompts"
      v-if="searchPromptPopupVisible"
      @close="toggleSearchPromptPopup"
      @search="searchPrompts"
      @select-prompt="handleSelectPrompt"
    />
  </div>
</template>

<style scoped>
.app {
  display: flex;
  flex-direction: row;
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}

</style>
