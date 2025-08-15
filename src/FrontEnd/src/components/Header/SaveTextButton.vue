<template>
  <button class="save-text-button" @click="$emit('save')">
    Save Text
  </button>
</template>

<script>
export default {
  name: 'SaveTextButton'
}
</script>

<style scoped>
.save-text-button {
  font-size: 2rem;
  font-weight: bold;
  background-color: green;
  color: white;
  border: 1px solid rgb(200, 200, 200);
  border-radius: 5px;
  cursor: pointer;
  height: 50px;
  width: 200px;
}
.save-text-button:hover {
  background-color: rgb(200, 200, 200);
}
</style>
