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
    X
  </button>
</template>

<style scoped>
.delete-prompt-button {
  color: white;
  background: none;
  border: none;
  margin-top: 5px;
  cursor: pointer;
  font-size: 1rem;
}
</style>