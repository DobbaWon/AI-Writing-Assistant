<script>
import DeletePromptButton from './DeletePromptButton.vue';

export default {
  name: 'SideBar',
  props: {
    promptList: {
      type: Array,
      required: true
    },
  },
  components: {
    DeletePromptButton,
  },
  methods: {
    handleDeletePrompt(promptId) {
      this.$emit('delete-prompt', promptId);
    },
    handleSelectPrompt(item) {
      this.$emit('select-prompt', item); // item = promptID
    },
    formatLastModified(date) {
      return new Date(date).toLocaleDateString('en-GB', {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit'
      });
    }
  },
}
</script>

<template>
  <div class="sidebar">
    <ul>
      <li v-for="(item, index) in promptList" :key="index">
        <div class="prompt-title" @click="handleSelectPrompt(item)">
          {{ item.prompt }}
          <DeletePromptButton :promptId="item.id" @delete-prompt="handleDeletePrompt" />
        </div>
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
  padding: 20px;
  margin-bottom: 4px;
  color: white;
  cursor: pointer;
  font-size: 1.5rem;
  background-color: #121212;
}
.sidebar li:hover {
  background-color: #2c2c2c;
}
.delete-prompt-button {
  float: right;
}
.delete-prompt-button:hover {
  color: red;
}
</style>
