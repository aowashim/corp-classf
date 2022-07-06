import SignIn from './pages/SignIn'
import SignUp from './pages/SignUp'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { CssBaseline } from '@material-ui/core'
import PostOrder from './pages/PostOrder'

function App() {
  return (
    <>
      <CssBaseline />

      <BrowserRouter>
        <Routes>
          {/* <Route index element={<Home />} /> */}
          <Route path='signin' element={<SignIn />} />
          <Route path='signup' element={<SignUp />} />
          <Route path='postoffer' element={<PostOrder />} />
        </Routes>
      </BrowserRouter>
    </>
  )
}

export default App