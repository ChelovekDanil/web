import { useEffect } from 'react';
import './App.css';
import useRoutes from './components/Routes';
import useAuth from './components/forAuth/useAuth';
import TokenValidator from './components/axios/TokenValidator';

const App = () => {
  const routes = useRoutes();
  const {setAuth } = useAuth();

  useEffect(() => {
    if (TokenValidator()) {
      setAuth(true);
    } 
    else {
      setAuth(false);
    }
  }, [setAuth])

  return (
    <div className="App"> 
      {routes}
    </div>
  );
}

export default App;
