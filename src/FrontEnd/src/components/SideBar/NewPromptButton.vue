<script>
export default {
  name: 'NewPromptButton',
  methods: {
    handleNewPrompt() {
      this.$emit('new-prompt');
    }
  }
}
</script>

<template>
  <button class="new-prompt-button" @click="handleNewPrompt">
    + New Prompt
  </button>
</template>

<style scoped>
.new-prompt-button {
  background-color: transparent; 
  border: none;
  border-bottom: 2px solid #333333;
  color: white;
  padding: 20px 20px;
  width: 100%;
  text-align: left;
  font-size: 1.8rem;
  font-weight: bold;
  margin-top: 80px;
  padding-left: 30px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s ease;
}

.new-prompt-button:hover {
  background-color: #2c2c2c;
}
</style>