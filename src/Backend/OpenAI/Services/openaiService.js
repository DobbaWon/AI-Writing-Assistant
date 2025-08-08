import OpenAI from 'openai';
import dotenv from 'dotenv';

dotenv.config({ path: './src/Backend/OpenAI/.env' }); // adjust path as needed
const openai = new OpenAI({
  apiKey: process.env.OPENAI_API_KEY
});

export const generateAIPromptsService = async (existingPrompts = [], existingAIPrompts = []) => {
  try {
    const systemMessage = `Generate a list of 3 creative writing prompts that are less than 100 characters long. Avoid using any prompts that are similar to the following: ${existingPrompts.join(', ')}. Also, avoid using any prompts that are similar to the following AI-generated prompts: ${existingAIPrompts.join(', ')}. If there is nothing available, please create new and unique prompts. The prompts should be unique and engaging. Return the prompts in a list format, with no numbers, with each prompt on a new line. Do not include any additional text or explanations.`;

    const response = await openai.chat.completions.create({
      model: 'gpt-4o-mini',
      messages: [
        { role: 'system', content: 'You are a prompt generator. Do not send any filler text, only the prompts.' },
        { role: 'user', content: systemMessage }
      ]
    });

    return response.choices[0].message.content
      .split('\n')
      .filter(line => line.trim() !== '');
  } catch (error) {
    console.error('Error generating AI prompts:', error);
    throw new Error('Failed to generate AI prompts');
  }
};
