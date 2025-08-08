<script>
export default {
  name: 'SubmitPromptButton'
}
</script>

<template>
  <button class="submit-prompt-button" @click="$emit('submit')">
    Submit Prompt
  </button>
</template>

<style scoped>
.submit-prompt-button {
  position: absolute;
  bottom: 10px;
  left: 50%;
  transform: translateX(-50%);
  width: 35%;
  height: 50px;
  font-size: 1.2rem;
  font-weight: bold;
  background-color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
}
.submit-prompt-button:hover {
  background-color: rgb(200, 200, 200);
}
</style>
