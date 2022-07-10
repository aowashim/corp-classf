import { Toolbar } from '@material-ui/core'
import React from 'react'
import { useLocation } from 'react-router-dom'
import NavBar from '../components/NavBar'

export default function Home() {
  const { pathname } = useLocation()

  return (
    <div>
      <NavBar path={pathname} />
      <Toolbar />

      <h1>Home Page</h1>
    </div>
  )
}
