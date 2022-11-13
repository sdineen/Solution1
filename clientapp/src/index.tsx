//import default component from react module and name it React
import React from 'react';
import ReactDOM from 'react-dom/client';
import App from './components/App';

// get div with id = 'root'
const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <App />
);


