import SignIn from './pages/SignIn'
import SignUp from './pages/SignUp'
import { BrowserRouter, Routes, Route } from 'react-router-dom'
import { CssBaseline } from '@material-ui/core'
import PostOffer from './pages/PostOffer'
import Profile from './pages/Profile'
import Home from './pages/Home'
import UserContext from './store/UserContext'
import { useMemo, useState } from 'react'
import OfferFeed from './pages/OfferFeed'

function App() {
  const [user, setUser] = useState({
    id: '123',
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
            <Route path='postoffer' element={<PostOffer />} />
            <Route path='profile' element={<Profile />} />
            <Route path='offers' element={<OfferFeed />} />
          </Routes>
        </UserContext.Provider>
      </BrowserRouter>
    </>
  )
}

export default App
