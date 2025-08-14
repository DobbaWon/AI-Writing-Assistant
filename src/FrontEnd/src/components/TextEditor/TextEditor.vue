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
      type: Object,
      default: () => ({ prompt: 'No Prompt Provided', text: '' })
    }
  },
  methods: {
    saveText() {
      this.$emit('save-text', this.prompt, this.editorText);
    },
    getFeedback() {
      this.$emit('get-feedback', this.prompt, this.editorText);
    }
  },
  data() {
    return {
      editorText: '',
    };
  },
  watch: {
    prompt: {
      immediate: true,
      handler(newPrompt) {
        if (newPrompt && newPrompt.text !== undefined) {
          this.editorText = newPrompt.text;
        } else {
          this.editorText = "";
        }
      }
    }
  },
}
</script>

<template>
  <div class="text-editor">
    <EditorHeader :prompt="prompt.prompt" @save-text="saveText" @get-feedback="getFeedback"/>
    <textarea class="editor-textarea" placeholder="Type your text here..." v-model="editorText"></textarea>
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
  font-size: 1.4rem;
  outline: none;
  border-bottom: 2px solid #7e7e7e;

  background-color: rgb(32, 32, 32);
  color: white;
}
</style>

