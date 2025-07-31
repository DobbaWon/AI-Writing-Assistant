<script>
import EditorHeader from './EditorHeader.vue';
import FeedbackBox from './FeedbackBox.vue';

export default {
  name: 'TextEditor',
  components: {
    EditorHeader,
    FeedbackBox
  },
  props: {
    prompt: {
      type: String,
      default: 'No Prompt Provided'
    },
  },
  methods: {
    saveText() {
      this.$emit('save-text', this.prompt, this.$refs.editorTextarea.value);
    }
  },
}
</script>

<template>
  <div class="text-editor">
    <EditorHeader :prompt="prompt" @save-text="saveText" />
    <textarea class="editor-textarea" placeholder="Type your text here..." ref="editorTextarea"></textarea>
    <FeedbackBox />
  </div>
</template>

<style scoped>
.text-editor {
  flex: 1;
  overflow: hidden;
  background-color: rgb(61, 61, 61);
  border: 2px solid #7e7e7e;

}
.editor-textarea {
  width: 100%;
  height: 90vh;
  resize: none;
  padding: 10px;
  font-size: 16px;
  outline: none;
  border-bottom: 2px solid #7e7e7e;

  background-color: rgb(32, 32, 32);

}
</style>

