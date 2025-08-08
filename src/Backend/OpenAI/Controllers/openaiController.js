import { generateAIPromptsService } from '../Services/openaiService.js';

export const generateAIPrompts = async (req, res) => {
  try {
    const { currentPrompts } = req.body; // expect array from frontend
    const prompts = await generateAIPromptsService(currentPrompts);
    res.json(prompts);
  } catch (error) {
    res.status(500).json({ error: error.message });
  }
};
