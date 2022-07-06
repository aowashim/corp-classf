import SignIn from './pages/SignIn';
import SignUp from './pages/SignUp';
import OfferFeed from "./pages/OfferFeed";
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { CssBaseline } from '@material-ui/core'

function App() {
  return (
    <>
      <CssBaseline />

      <BrowserRouter>
        <Routes>
          {/* <Route index element={<Home />} /> */}
          <Route path="offerfeed" element={<OfferFeed />} />
          <Route path="signin" element={<SignIn />} />
          <Route path="signup" element={<SignUp />} />
        </Routes>
      </BrowserRouter>
    </>
  );
}

export default App
