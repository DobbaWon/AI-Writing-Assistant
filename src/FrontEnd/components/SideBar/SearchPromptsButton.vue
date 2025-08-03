<script>
export default {
  name: 'SearchPromptButton',
  methods: {
    handleSearchPrompt() {
      this.$emit('search-prompt');
    }
  }
}
</script>

<template>
  <button class="search-prompt-button" @click="handleSearchPrompt">
    🔍 Search Prompt
  </button>
</template>

<style scoped>
.search-prompt-button {
  background-color: transparent; 
  border: none;
  border-bottom: 2px solid #333333;
  color: white;
  padding: 20px 20px;
  width: 100%;
  text-align: left;
  font-size: 1.8rem;
  font-weight: bold;
  margin-bottom: 80px;
  margin-top: 5px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.3s ease;
}

.search-prompt-button:hover {
  background-color: #2c2c2c;
}
</style>