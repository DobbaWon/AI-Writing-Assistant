<script>
import DeletePromptButton from './SideBar/DeletePromptButton.vue';

  export default {
  name: 'SearchPromptPopup',
  components: {
    DeletePromptButton
  },
  props: {
    searchedPrompts: {
      type: Array,
      required: true
    }
  },
  methods: {
    closePopup() {
      this.$emit('close');
    },
    searchPrompts() {
      const searchTerm = this.$refs.searchInput.value;
      if (!searchTerm) {
        this.$emit('search', ''); // Emit empty search to reset
        return;
      }
      this.$emit('search', searchTerm);
    },
    handleSelectPrompt(prompt) {
      this.$emit('select-prompt', prompt);
      this.closePopup(); // Close the popup after selecting a prompt
    }
  },
}
</script>

<template>
  <div class="search-popup">
    <textarea type="text" ref="searchInput" placeholder="Search Prompts" @input="searchPrompts"/>
    <DeletePromptButton @delete-prompt="closePopup" />
    <ul>
      <li v-for="prompt in searchedPrompts" :key="prompt.id" @click="handleSelectPrompt(prompt)">
        {{ prompt.prompt }}
      </li>
    </ul>
  </div>
</template>

<style scoped>
.search-popup {
  position: absolute;
  width: 40vw;
  height: 60vh;
  top: 15%;
  left: 30%;
  background-color: rgb(127, 124, 124);
  border: 2px solid white;
  border-radius: 10px;
}

.search-popup textarea { /* Textarea for user input */
  width: 90%;
  height: 10%;
  background-color: transparent;
  color: white;
  margin: 20px auto;
  display: block;
  padding: 10px;
  font-size: 2rem;
  overflow: hidden;
  resize: none;
  border:none;
  border-bottom: 1px solid white;
}
.search-popup textarea::placeholder {
  color: white;
  opacity: 0.7;
}

.search-popup textarea:focus {
  outline: none;
}
.delete-prompt-button {
  position: absolute;
  top: 10px;
  right: 10px;
  cursor: pointer;
  color: white;
  font-size: 1.8rem;
  padding: 10px;
  padding-right: 20px;
}

.search-popup ul {
  list-style: none;
  padding: 0;
}

.search-popup li {
  padding: 20px;
  margin-left: 25px;
  margin-right: 25px;
  margin-bottom: 4px;
  color: white;
  cursor: pointer;
  font-size: 1.5rem;
  background-color: #3a3737;
  border-radius: 15px;
  transition: background-color 0.3s ease;
  border-bottom: 2px solid #333333;
}
.search-popup li:hover {
  background-color: #2c2c2c;
}
</style>