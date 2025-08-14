import express from 'express';
import { generateAIPrompts } from '../Controllers/openaiController.js';
import { generateAIFeedback } from '../Controllers/openaiController.js';

const router = express.Router();

router.post('/ai-prompts', generateAIPrompts);
router.post('/ai-feedback', generateAIFeedback);

export default router;
