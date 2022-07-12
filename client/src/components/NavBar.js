import {
  AppBar,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from '@material-ui/core'
import MenuIcon from '@material-ui/icons/Menu'
import { useContext, useState } from 'react'
import AccountCircleIcon from '@material-ui/icons/AccountCircle'
import { useNavigate } from 'react-router-dom'
import UserContext from '../store/UserContext'

export default function NavBar({ path }) {
  const navigate = useNavigate()
  const [anchorEl, setAnchorEl] = useState(null)
  const { user, setUser } = useContext(UserContext)

  const handleClick = event => {
    setAnchorEl(event.currentTarget)
  }

  const handleClose = () => {
    setAnchorEl(null)
  }

  const handleLogout = () => {
    localStorage.removeItem('id')
    localStorage.removeItem('token')

    setUser({
      id: '',
      token: '',
    })
  }

  const handleNavigate = curPath => {
    if (path !== curPath) {
      navigate(curPath)
    } else {
      handleClose()
    }
  }

  return (
    <div>
      <AppBar position='fixed'>
        <Toolbar style={{ justifyContent: 'space-between' }}>
          {/* <div
              style={{
                display: 'flex',
                //flexDirection: 'column',
                //padding: 5,
              }}
            > */}
          <IconButton
            onClick={handleClick}
            edge='start'
            color='inherit'
            aria-label='menu'
          >
            <MenuIcon />
          </IconButton>
          <Typography
            align='center'
            variant='h5'
            style={{
              //marginTop: 4,
              color: '#ffe6b0',
              textShadow: '2px 2px 8px #FF0000',
            }}
          >
            Corporate Classifieds
          </Typography>
          {/* </div> */}
          <IconButton
            color='inherit'
            aria-label='cart'
            onClick={() => handleNavigate('/profile')}
          >
            <AccountCircleIcon />
          </IconButton>
          <Menu
            // anchorEl={anchorEl}
            // keepMounted
            open={Boolean(anchorEl)}
            // onClose={handleClose}
            anchorEl={anchorEl}
            anchorOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            keepMounted
            transformOrigin={{
              vertical: 'top',
              horizontal: 'right',
            }}
            //open={open}
            onClose={handleClose}
          >
            <MenuItem onClick={() => handleNavigate('/')}>Offers</MenuItem>
            {/* <MenuItem onClick={() => handleNavigate('/')}>Products</MenuItem> */}
            <MenuItem onClick={() => handleNavigate('/postoffer')}>
              Post Offer
            </MenuItem>
            {user.id ? (
              <MenuItem onClick={handleLogout}>Sign Out</MenuItem>
            ) : (
              <MenuItem onClick={() => handleNavigate('/signin')}>
                Sign In
              </MenuItem>
            )}
            <MenuItem onClick={() => handleNavigate('/more')}>More</MenuItem>
          </Menu>
        </Toolbar>
      </AppBar>
    </div>
  )
}
