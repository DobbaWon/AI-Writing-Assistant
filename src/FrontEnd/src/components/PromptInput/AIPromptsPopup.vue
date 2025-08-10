<script>
import DeletePromptButton from '../SideBar/DeletePromptButton.vue';
import GeneratingPromptsPlaceholder from './GeneratingPromptsPlaceholder.vue';

export default {
  name: 'AIPromptsPopup',
  components: {
    DeletePromptButton,
    GeneratingPromptsPlaceholder
  },
  props: {
    prompts: {
      type: Array,
      required: false,
      default: () => []
    }
  },
  methods: {
    closeInput() {
      this.$emit('close-input');
    },
    regeneratePrompts() {
      this.$emit('regenerate-prompts');
    },
    selectPrompt(prompt) {
      this.$emit('prompt-selected', prompt);
    },
    closeBoth() {
      this.$emit('close');
    }
  },
}
</script>

<template>
  <div class="ai-prompts-popup">
    <div class="header">
      <h1>AI-Generated Prompts</h1>
      <DeletePromptButton @delete-prompt="closeBoth" />
    </div>

    <div class="main-content">
      <div class="content">
          <h2>Select a prompt to use:</h2>
        <ul v-if="prompts.length > 0">
          <li v-for="(prompt, index) in prompts" :key="index" @click="selectPrompt(prompt)">
            {{ prompt }}
          </li>
        </ul>
        <GeneratingPromptsPlaceholder class="loading-icon" v-else/>
      </div>

      <div class="regenerate-section">
        <p>Need a new prompt? Click the button below to generate 3 brand new ones!</p>
        <button class="regenerate-button" @click="regeneratePrompts">Regenerate Prompts</button>
        <button class="go-back-button" @click="closeInput">Go Back</button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.ai-prompts-popup {
  position: absolute;
  width: 40vw;
  height: 45vh;
  top: 18%;
  left: 30%;
  background-color: rgb(127, 124, 124);
  border: 2px solid white;
  border-radius: 10px;
}

.main-content {
  display: flex;
  flex-direction: row;
}
h1{ /* Prompt Input Title */
  text-align: center;
  color: rgb(241, 239, 239);
  font-weight: bold;
  padding-bottom: 10px;
  border-bottom: 1px solid rgb(185, 183, 183);
}

.delete-prompt-button { /* Delete Prompt Button */
  position: absolute;
  top: 20px;
  right: 20px;
  cursor: pointer;
  color: white;

}
.delete-prompt-button:hover {
  color: red;
}

.content {
  width: 65%;
}

.ai-prompts-popup ul {
  list-style: none;
}

.ai-prompts-popup li {
  padding: 20px;
  margin: 20px 0;
  background-color: #f0f0f0;
  border-radius: 5px;
  cursor: pointer;
  width: 100%;
  font-size: 1.4rem;
  display: flex;
  justify-content: space-between;
}

.ai-prompts-popup li:hover {
  background-color: #cbc9c9; 
  transition: background-color 0.3s ease;

}

h2 { /*AI Prompt Title */
  text-align: center;
  color: rgb(241, 239, 239);
  font-weight: bold;
}

.regenerate-section {
  text-align: center;
  margin-top: 70px;
  width: 35%;
}

.regenerate-button {
  width: 51%;
  height: 70px;
  font-size: 1.2rem;
  font-weight: bold;
  background-color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
}

button:hover {
  background-color: #cccaca;
  transition: background-color 0.3s ease;
}

.loading-icon {
  position: absolute;
  top: 240px;
  left: 300px;
}

p {
  color:white;
  font-size: 1.6rem;
  margin-left: 20px;
  margin-right: 20px;
}

.go-back-button {
  width: 51%;
  height: 70px;
  margin-top: 30px;
  font-size: 1.2rem;
  font-weight: bold;
  background-color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
}
</style>
