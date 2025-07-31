<script>
export default {
  name: 'DeletePromptButton',
  props: {
    promptId: {
      type: String,
      required: true
    }
  },
  methods: {
    deletePrompt() {
      this.$emit('delete-prompt', this.promptId);
    }
  }
}
</script>

<template>
  <button @click="deletePrompt" class="delete-prompt-button">
    Delete Prompt
  </button>
</template>

<style scoped>
.delete-prompt-button {
  background-color: #ff4d4d;
  color: white;
  border: none;
  padding: 10px 15px;
  border-radius: 5px;
  cursor: pointer;
  font-size: 1rem;
}
.delete-prompt-button:hover {
  background-color: #ff1a1a;
}
</style>