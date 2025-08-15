<script>
import GetFeedbackButton from './GetFeedbackButton.vue';
import SaveTextButton from './SaveTextButton.vue';
import DownloadButton from './DownloadButton.vue';

export default {
  name: 'EditorHeader',
  components: {
    SaveTextButton,
    GetFeedbackButton,
    DownloadButton
  },
  props: {
    prompt: {
      type: String,
      default: 'No Prompt Provided'
    }
  },
  methods: {
    saveText() {
      this.$emit('save-text');
    },
    getFeedback(){
      this.$emit('get-feedback');
    },
    download(){
      this.$emit('download');
    }
  }
}
</script>

<template>
  <div class="editor-header">
    <h1>{{ prompt }}</h1>
    <DownloadButton @download="download"/>
    <GetFeedbackButton @get-feedback="getFeedback"/>
    <SaveTextButton @save="saveText" />
  </div>
</template>

<style scoped>
.editor-header {
  background-color: rgb(32, 32, 32);
  border-bottom: 2px solid #7e7e7e;
  height: 10vh;
  display: flex;
  align-items: center;
  justify-content: center;
}

.editor-header {
  width: 100%;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 2rem;
}

h1 {
  color: white;
  font-size: 2rem;
  font-weight: bold;
}

.download-button {
  margin-left: 20vw;
  margin-right: 1.5vw;
}

</style>