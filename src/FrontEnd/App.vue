<script setup>
import PromptInput from './components/PromptInput/PromptInput.vue';
import SideBar from './components/SideBar/SideBar.vue';
import TextEditor from './components/TextEditor/TextEditor.vue';
import { onMounted, ref } from 'vue';
import axios from 'axios';

const promptInputVisible = ref(true);
const promptList = ref([]);
const prompt = ref('');

// Function to toggle the visibility of the PromptInput component
const togglePromptInput = () => {
  promptInputVisible.value = !promptInputVisible.value;
};

// Function to handle the prompt submission from PromptInput
const handlePromptSubmitted = async (submittedPrompt) => {
  prompt.value = submittedPrompt;

  try {
    await axios.post('http://localhost:5221/api/promptentries', {
      prompt: submittedPrompt,
      text: '',
    });
    console.log('Prompt successfully saved to DB');


  } catch (error) {
    console.error('Failed to save prompt:', error);
  }

  await fetchPrompts();
  togglePromptInput();
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

onMounted(async () => {
  // Get the list of prompts from the backend
  await fetchPrompts();

  console.log('App mounted, prompts fetched:', promptList.value);
});
</script>

<template>
  <div class="app">
    <SideBar :promptList="promptList" />
    <TextEditor :prompt="prompt" />
    <PromptInput v-if="promptInputVisible == true" @prompt-submitted="handlePromptSubmitted" />
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
