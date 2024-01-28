import './App.css';
import Image from './components/images/Image';
import { Routes, Route } from 'react-router-dom';

function App() {
  return (
    <div className="App"> 
      <Routes>
        <Route path='/' element={<Image/>} />
        <Route path='/popular' element={<Image/>} />
        <Route path='/films' element={<Image/>} />
        <Route path='/serials' element={<Image/>} />
      </Routes>
    </div>
  );
}

export default App;
