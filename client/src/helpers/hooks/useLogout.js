import { useContext } from 'react'
import UserContext from '../../store/UserContext'

const useLogout = () => {
  const { setUser } = useContext(UserContext)

  const handleLogout = () => {
    localStorage.removeItem('id')
    localStorage.removeItem('token')

    setUser({
      id: '',
      token: '',
    })
  }

  return handleLogout
}

export default useLogout
