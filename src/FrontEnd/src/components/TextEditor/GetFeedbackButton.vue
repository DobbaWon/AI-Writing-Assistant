<script>
export default{
  name: 'GetFeebackButton',
  methods: {
    getFeedback() {
      this.$emit('get-feedback')
    }
  }
}
</script>

<template>
  <button class="get-feedback-button" @click="getFeedback">Get AI Feedback</button>
</template>

<style>
.get-feedback-button {
  font-size: 2rem;
  font-weight: bold;
  background-color: rgb(11, 168, 176);
  color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
  height: 50px;
  width: 300px;
  margin-right: 40px;
}
.get-feedback-button:hover {
  background-color: rgb(200, 200, 200);
}
</style>