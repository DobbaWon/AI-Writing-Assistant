<script setup>
import SideBar from './components/SideBar/SideBar.vue';
import TextEditor from './components/TextEditor/TextEditor.vue';

</script>

<template>
  <div class="app">
    <SideBar />
    <TextEditor />
  </div>
</template>

<style scoped>
.app {
  display: flex;
  flex-direction: row;
  height: 100vh;
  width: 100vw;
  overflow: hidden;
}
</style>
