import SignIn from './pages/SignIn'
import SignUp from './pages/SignUp'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { CssBaseline } from '@material-ui/core'
import PostOrder from './pages/PostOrder'
import Profile from './pages/Profile'
import Home from './pages/Home'
import UserContext from './store/UserContext'
import { useMemo, useState } from 'react'

function App() {
  const [user, setUser] = useState({
    id: '',
    token: '',
  })

  const userMemo = useMemo(
    () => ({
      user,
      setUser,
    }),
    [user.token]
  )

  return (
    <>
      <CssBaseline />

      <BrowserRouter>
        <UserContext.Provider value={userMemo}>
          <Routes>
            <Route index element={<Home />} />
            <Route path='signin' element={<SignIn />} />
            <Route path='signup' element={<SignUp />} />
            <Route path='postoffer' element={<PostOrder />} />
            <Route path='profile' element={<Profile />} />
          </Routes>
        </UserContext.Provider>
      </BrowserRouter>
    </>
  )
}

export default App
