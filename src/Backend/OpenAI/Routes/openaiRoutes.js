import express from 'express';
import { generateAIPrompts } from '../Controllers/openaiController.js';

const router = express.Router();

router.post('/ai-prompts', generateAIPrompts);

export default router;
