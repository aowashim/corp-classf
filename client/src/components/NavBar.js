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
import { MuiThemeProvider, createTheme } from '@material-ui/core/styles'
import { appBackground, appPrimary } from '../helpers/constant'

const theme2 = createTheme({
  palette: {
    primary: {
      main: '#FFFFFF',
    },
    secondary: {
      main: '#F03D5F',
    },
  },
})

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
      <MuiThemeProvider theme={theme2}>
        <AppBar position='fixed' style={{ backgroundColor: appPrimary }}>
          <Toolbar style={{ justifyContent: 'space-between', height: '70px' }}>
            {/* <div
              style={{
                display: 'flex',
                //flexDirection: 'column',
                //padding: 5,
              }}
            > */}
            {/* <Typography variant='title' component='h6'> */}
            <img src='/LogoComplete.png' alt='logo' height={50} />
            {/* </Typography> */}
            <div className='cor'>
              <IconButton
                onClick={handleClick}
                edge='start'
                color='inherit'
                aria-label='menu'
              >
                <MenuIcon />
              </IconButton>

              {/* <Typography
              align="center"
              variant="h4"
              style={{
                fontWeight: 600,
                color: "#17282F",
                // textShadow: "2px 2px 8px #FF0000",
              }}
            >
              Corporate Classifieds
            </Typography> */}
              {/* </div> */}
              <IconButton
                color='inherit'
                aria-label='cart'
                onClick={() => handleNavigate('/profile')}
              >
                <AccountCircleIcon />
              </IconButton>
            </div>

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
              <MenuItem onClick={() => handleNavigate('/offers')}>
                Offers
              </MenuItem>
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
      </MuiThemeProvider>
    </div>
  )
}
