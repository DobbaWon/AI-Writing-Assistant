<script>
import DeletePromptButton from './DeletePromptButton.vue';

export default {
  name: 'SideBar',
  props: {
    promptList: {
      type: Array,
      required: true
    },
    currentPrompt: {
      type: Object,
      default: () => ({})
    }
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
      <li
        v-for="(item, index) in promptList"
        :key="index"
        :class="{'current-prompt-title': currentPrompt.prompt === item.prompt}"
        @click="handleSelectPrompt(item)"
      >
        {{ item.prompt }}
        <DeletePromptButton :promptId="item.id" @delete-prompt="handleDeletePrompt" />
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
  border-radius: 15px;
  transition: background-color 0.3s ease;
}
.current-prompt-title {
  background-color: #4b4b4b !important; /* I love that labelling it important fixed my issue */
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
