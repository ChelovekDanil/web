import { useEffect } from 'react';
import './App.css';
import useRoutes from './components/Routes';
import { getItemLocalStorage } from './components/localStorege/localStorage';
import useAuth from './components/forAuth/useAuth';

const App = () => {
  const routes = useRoutes();
  const {setAuth } = useAuth();

  useEffect(() => {
    if (getItemLocalStorage("isAuth") === "true") {
      setAuth(true);
    }
    else {
      setAuth(false);
      console.log("skflsajkfldj");
    }
  }, [setAuth])

  return (
    <div className="App"> 
      {routes}
    </div>
  );
}

export default App;
