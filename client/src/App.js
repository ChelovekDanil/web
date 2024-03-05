import './App.css';
import useRoutes from './components/Routes';

const App = () => {
  const routes = useRoutes();

  return (
    <> 
      {routes}
    </>
  );
}

export default App;