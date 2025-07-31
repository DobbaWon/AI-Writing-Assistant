<script>
export default {
  name: 'SideBar',
  props: {
    promptList: {
      type: Array,
      required: true
    },
  },
  components: {
    DeletePromptButton: () => import('./DeletePromptButton.vue'),
  },
}
</script>

<template>
  <div class="sidebar">
    <ul>
      <li v-for="(item, index) in promptList" :key="item.id">
        {{ item.prompt }}
      </li>
    </ul>
  </div>
</template>

<style scoped>
.sidebar {
  width: 15vw;
  background-color: #0a0a0a;
  height: 100vh;
  overflow-y: auto;
}
.sidebar ul {
  list-style-type: none;
  padding: 0;
}
.sidebar li {
  padding: 10px;
  color: white;
  cursor: pointer;
  font-size: 2rem;
}
</style>
