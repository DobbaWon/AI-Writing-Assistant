<script>
export default {
  name: 'EditorHeader',
  props: {
    prompt: {
      type: String,
      default: 'No Prompt Provided'
    }
  }
}

</script>

<template>
  <div class="editor-header">
    <h1>{{ prompt }}</h1>
  </div>
</template>

<style scoped>
.editor-header {
  background-color: rgb(32, 32, 32);

  border-bottom: 2px solid #7e7e7e;
  height: 10vh;
  flex: 1;
  overflow: hidden;
}

h1 {
  color: white;
  font-size: 3rem;
  font-weight: bold;
  margin-left: 2rem;
}
</style>