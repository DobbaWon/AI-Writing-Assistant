<script>
import DeletePromptButton from '../SideBar/DeletePromptButton.vue';

export default {
  name: 'FeedbackBox',
  components: {
    DeletePromptButton
  },
  methods: {
    close(){
      this.$emit('close');
    }
  },
  props:{
    feedback: {
      type: String,
      default: "Waiting for AI Feedback"
    }
  }
}
</script>

<template>
  <div class="feedback-box">
    <h1>AI Feedback</h1>
    <p>{{ feedback }}</p>
  </div>
</template>

<style scoped>
.feedback-box {
  background-color: rgb(32, 32, 32);
  border: 2px solid #7e7e7e;
  height: 40vh;
  width:  85vw;
  position: fixed;
  left: 15vw;
  right: 0;
  bottom: 0;
  overflow: hidden;
  overflow-y: auto;
  font-size: 1.5rem;

  transform: translateY(100%);
  animation: slideUp 0.4s ease-out forwards;
}

@keyframes slideUp {
  from {
    transform: translateY(100%);
  }
  to {
    transform: translateY(0);
  }
}

h1{
  margin-left: 1vw;
  color: white;
  font-weight: bold;
}

p{
  margin-left: 1vw;
  color: white;
}
</style>
