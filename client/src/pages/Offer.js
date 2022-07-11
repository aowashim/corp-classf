import React, { useContext, useEffect, useState } from 'react'
import NavBar from '../components/NavBar'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import { useLocation, useParams } from 'react-router-dom'
import Link from '@material-ui/core/Link'
import { Button, Toolbar } from '@material-ui/core'
import FavoriteIcon from '@material-ui/icons/Favorite'
// import CalendarMonthIcon from '@material-ui/icons/CalendarMonth'
import Comment from '../components/Comment'
import Divider from '@material-ui/core/Divider'
import WriteComment from '../components/WriteComment'
import { getOfferDetailsApi } from '../helpers/API/offer'
import Loading from '../components/Loading'
import { jsonToNormalDate } from '../helpers/convertDate'
import userEvent from '@testing-library/user-event'
import UserContext from '../store/UserContext'

function Copyright() {
  return (
    <Typography variant='body2' color='textSecondary' align='center'>
      {'Copyright © '}
      <Link color='inherit' href='https://mui.com/'>
        Your Website
      </Link>{' '}
      {new Date().getFullYear()}
      {'.'}
    </Typography>
  )
}

const useStyles = makeStyles(theme => ({
  icon: {
    marginRight: theme.spacing(2),
  },
  heroContent: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(8, 0, 6),
  },
  heroButtons: {
    marginTop: theme.spacing(4),
  },
  cont_each: {
    padding: '1rem',
  },
  bnn: {
    display: 'flex',
    justifyContent: 'space-between',
  },
  cmtsec: {
    marginTop: '2rem',
  },
  card: {
    height: '100%',
    boxShadow: '0px 0px 10px 0px rgba(94,94,94,0.64)',
    display: 'flex',
    border: '1rem',
    padding: '5rem',
    borderRadius: '10px',
    flexDirection: 'column',
  },
}))

export default function Offer() {
  const classes = useStyles()
  const { pathname } = useLocation()
  const { id } = useParams()
  const [isLoaded, setIsLoaded] = useState(false)
  const [offerData, setOfferData] = useState('')
  const { user } = useContext(UserContext)

  useEffect(() => {
    handleGetOfferDetails()
  }, [])

  const handleGetOfferDetails = async () => {
    const res = await getOfferDetailsApi(id)

    if (res.status === 200) {
      setOfferData(res.data[0])
      setIsLoaded(true)
    } else {
      alert('An error occurred, please try again...')
    }
  }

  return (
    <div>
      <NavBar path={pathname} />
      <Toolbar />

      {/* <div className={classes.heroContent}></div> */}

      {isLoaded ? (
        <Container component='main' className={classes.card} maxWidth='md'>
          <Container className={classes.cont_each} maxWidth='md'>
            <Typography variant='h4' align='left'>
              {offerData.empName}
            </Typography>
            <Typography variant='h6' align='left'>
              {jsonToNormalDate(offerData.o.start_Date)}
            </Typography>
          </Container>
          <Container maxWidth='md'>
            <Typography variant='h2' align='center'>
              {offerData.o.title}
            </Typography>
            <Typography
              className={classes.cont_each}
              variant='subtitle1'
              align='justify'
            >
              {offerData.o.description}
            </Typography>
          </Container>
          <Container className={classes.bnn} maxWidth='md'>
            <Button size='large' color='primary'>
              <FavoriteIcon />
              Like
            </Button>
            <Button size='large' color='primary'>
              Engage
            </Button>
          </Container>
          <Container className={classes.cmtsec}>
            <WriteComment eid={user.id} oid={offerData.o.id} />
          </Container>
          <Divider variant='fullWidth' style={{ margin: '30px 0' }} />
          <div>
            <Typography variant='h5' align='left'>
              Comments
            </Typography>
            {/* <Comment />
          <Comment /> */}
          </div>
        </Container>
      ) : (
        <Loading color='primary' size={50} />
      )}
    </div>
  )
}
