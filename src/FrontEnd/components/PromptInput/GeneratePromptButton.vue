<script>
export default {
  name: 'GeneratePromptButton'
}
</script>

<template>
  <button class="generate-prompt-button" @click="$emit('generate')">
    Generate Prompt
  </button>
</template>

<style scoped>
.generate-prompt-button {
  position: absolute;
  margin-left: 73%;
  margin-top: 10px;
  width: 20%;
  height: 50px;
  font-size: 1.2rem;
  font-weight: bold;
  background-color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
}
.generate-prompt-button:hover {
  background-color: rgb(200, 200, 200);
}
</style>
