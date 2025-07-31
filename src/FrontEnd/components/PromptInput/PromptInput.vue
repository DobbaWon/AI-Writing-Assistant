<script>
export default {
  name: 'PromptInput',
  methods: {
    submitPrompt() {
      if (this.$refs.promptTextarea.value.trim() === '') { // Check if the textarea is empty
        alert('Please enter a prompt before submitting.');
        return;
      }
      else{
        this.$emit('prompt-submitted', this.$refs.promptTextarea.value);
        this.$refs.promptTextarea.value = '';
      }
    }
  }
}
</script>

<template>
  <div class="prompt-input">
    <h1>Enter your writing prompt:</h1>
    <textarea
      ref="promptTextarea"
      class="prompt-textarea"
      placeholder="Type your prompt here..."
      @keydown.enter.prevent="submitPrompt"
    />

    <div class="AI-prompt">
      <h2> Or, use AI to generate a prompt:</h2>
      <button class="generate-prompt-button">Generate Prompt</button>
    </div>

    <button class="submit-prompt-button" @click="submitPrompt">Submit Prompt</button>
  </div>
</template>

<style scoped>
.prompt-input { /* Main container for the prompt input */
  position: absolute;
  width: 40vw;
  height: 32vh;
  top: 30%;
  left: 30%;
  background-color: rgb(127, 124, 124);
  border: 2px solid white;
  border-radius: 10px;
}
h1{ /* Prompt Input Title */
  text-align: center;
  color: rgb(241, 239, 239);
  font-weight: bold;
  padding-bottom: 10px;
  border-bottom: 1px solid rgb(185, 183, 183);
}
.prompt-textarea { /* Textarea for user input */
  width: 90%;
  height: 20%;
  margin: 20px auto;
  display: block;
  padding: 10px;
  border-radius: 5px;
  border: 1px solid rgb(200, 200, 200);
  font-size: 2rem;
  overflow: hidden;
  resize: none;
}
.AI-prompt { /* Container for AI prompt section */
  position: relative;
  width: 90%;
  height: 20%;
  display: flex;
  flex-direction: column;
  align-items: center;
}
h2 { /*AI Prompt Title */
  text-align: center;
  color: rgb(241, 239, 239);
  font-weight: bold;
}
button{
  width: 20%;
  height: 50px;
  font-size: 1.2rem;
  font-weight: bold;
  background-color: rgb(255, 255, 255);
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
}
button:hover {
  background-color: rgb(200, 200, 200);
}
.generate-prompt-button { /* Button to generate AI prompt */
  position: absolute;
  margin-left: 73%;
  margin-top: 10px;

}
.submit-prompt-button { /* Button to submit the prompt */
  position: absolute;
  bottom: 10px;
  left: 50%;
  transform: translateX(-50%);
  width: 35%;
}

</style>