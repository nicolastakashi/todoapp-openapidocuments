import { RedocStandalone } from 'redoc';
import File from './api.json'

function App() {
  return (
    <RedocStandalone
      specUrl={File}
      options={{
        hideSchemaTitles: true
      }}
    />
  );
}

export default App;
