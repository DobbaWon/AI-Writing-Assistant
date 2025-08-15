<template>
  <button class="download-button" @click="$emit('download')">
    Download
  </button>
</template>

<script>
export default {
  name: 'DownloadButton',
}
</script>

<style scoped>
.download-button {
  font-size: 2rem;
  font-weight: bold;
  background-color: orange;
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
