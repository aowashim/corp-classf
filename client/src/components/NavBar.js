import {
  AppBar,
  IconButton,
  Menu,
  MenuItem,
  Toolbar,
  Typography,
} from '@material-ui/core'
import MenuIcon from '@material-ui/icons/Menu'
import { useState } from 'react'
import AccountCircleIcon from '@material-ui/icons/AccountCircle'
import { useNavigate } from 'react-router-dom'
// import CartContext from '../store/CartContext'
// import UserContext from '../store/UserContext'
// import UserInfoContext from '../store/UserInfoContext'

export default function NavBar({ path }) {
  const navigate = useNavigate()
  const [anchorEl, setAnchorEl] = useState(null)
  //   const { user, setUser } = useContext(UserContext)
  //   const { setUserInfo } = useContext(UserInfoContext)
  //   const { cartVal, setCartVal } = useContext(CartContext)

  const user = true

  const handleClick = event => {
    setAnchorEl(event.currentTarget)
  }

  const handleClose = () => {
    setAnchorEl(null)
  }

  const handleLogout = () => {
    // sessionStorage.clear()
    // setUserInfo(false)
    // setCartVal(0)
    // setUser('')
    // history.push('/signin')
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
            <MenuItem onClick={() => handleNavigate('/profile')}>
              My Profile
            </MenuItem>
            {/* <MenuItem onClick={() => handleNavigate('/')}>Products</MenuItem> */}
            <MenuItem onClick={() => handleNavigate('/orders')}>
              Offers
            </MenuItem>
            {user ? (
              <MenuItem onClick={handleLogout}>Logout</MenuItem>
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
