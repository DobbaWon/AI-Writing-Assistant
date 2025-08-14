import { generateAIPromptsService } from '../Services/openaiService.js';
import { generateAIFeedbackService } from '../Services/openaiService.js';

export const generateAIPrompts = async (req, res) => {
  try {
    const { currentAIPrompts, currentPrompts } = req.body; // expect array from frontend
    const prompts = await generateAIPromptsService(currentAIPrompts, currentPrompts);
    res.json(prompts);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};

export const generateAIFeedback = async (req, res) => {
  try {
    const { prompt, text } = req.body; // ALl coming from the frontend again
    const feedback = await generateAIFeedbackService(prompt, text);
    res.json(feedback);
  } catch (error) {
    res.status(500).json({ error: error.message});
  }
}
