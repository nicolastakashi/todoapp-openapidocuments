import { RedocStandalone } from 'redoc';
import File from './api.json'

function App() {
  return (
    <RedocStandalone specUrl={File}/>
  );
}

export default App;
