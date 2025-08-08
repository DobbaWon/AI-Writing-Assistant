import express from 'express';
import cors from 'cors';
import bodyParser from 'body-parser';
import openaiRoutes from './Routes/openaiRoutes.js';


const app = express();

app.use(cors());
app.use(bodyParser.json());

app.use('/api/openai', openaiRoutes);

app.listen(5222, () => {
  console.log('Server running on port 5222');
});

