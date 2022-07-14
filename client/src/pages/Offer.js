import React, { useContext, useEffect, useState } from 'react'
import NavBar from '../components/NavBar'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import { useLocation, useParams } from 'react-router-dom'
import Link from '@material-ui/core/Link'
import { Box, Button, Toolbar } from '@material-ui/core'
import FavoriteIcon from '@material-ui/icons/Favorite'
// import CalendarMonthIcon from '@material-ui/icons/CalendarMonth'
import Comment from '../components/Comment'
import Divider from '@material-ui/core/Divider'
import WriteComment from '../components/WriteComment'
import { getCommentsApi, getOfferDetailsApi } from '../helpers/API/offer'
import Loading from '../components/Loading'
import { jsonToNormalDate } from '../helpers/convertDate'
import UserContext from '../store/UserContext'
import Alert from '@material-ui/lab/Alert'

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
  bnn: {
    display: 'flex',
    justifyContent: 'space-between',
    marginTop: 20,
    marginLeft: 140,
    marginRight: 140,
  },
  cmtsec: {
    marginBottom: 30,
    marginTop: 30,
  },
  card: {
    height: '100%',
    boxShadow: '0px 0px 10px 0px rgba(94,94,94,0.64)',
    display: 'flex',
    border: '1rem',
    padding: '2rem 5rem',
    borderRadius: '10px',
    flexDirection: 'column',
    marginTop: 30,
    marginBottom: 30,
  },
}))

export default function Offer() {
  const classes = useStyles()
  const { pathname } = useLocation()
  const { id } = useParams()
  const [isLoaded, setIsLoaded] = useState(false)
  const [offerData, setOfferData] = useState('')
  const { user } = useContext(UserContext)
  const [viewComment, setViewComment] = useState(false)
  const [commentData, setCommentData] = useState([])
  const [commentLoaded, setCommentLoaded] = useState(false)

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

  const handleGetComments = async () => {
    if (viewComment) {
      setViewComment(!viewComment)
      return
    }

    setViewComment(!viewComment)

    const res = await getCommentsApi(offerData.o.id)

    if (res.status === 200) {
      setCommentData(res.data)
      setCommentLoaded(true)
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
          <Typography align='center' variant='h5'>
            {offerData.o.title}
          </Typography>

          <div
            style={{
              display: 'flex',
              justifyContent: 'center',
              // width: '50%',
            }}
            align='center'
          >
            <div>
              <Alert
                style={{ marginBottom: 10, marginTop: 20 }}
                severity='success'
              >
                Offer Starts On : {jsonToNormalDate(offerData.o.start_Date)}
              </Alert>
              <Alert style={{ marginBottom: 20 }} severity='error'>
                Offer Ends On : {jsonToNormalDate(offerData.o.end_Date)}
              </Alert>

              <Button
                variant='contained'
                size='large'
                color='primary'
                style={{ marginBottom: 20, width: '100%' }}
              >
                <FavoriteIcon fontSize='small' style={{ marginRight: 5 }} />
                Like
              </Button>
            </div>
          </div>

          <Typography
            variant='subtitle2'
            align='justify'
            style={{ marginBottom: 5 }}
          >
            <u>Description</u> : {offerData.o.description}
          </Typography>

          <Typography
            variant='subtitle2'
            align='left'
            style={{ marginBottom: 5 }}
          >
            <u>Posted by</u> : <b>{offerData.empName}</b>
          </Typography>

          <Typography variant='subtitle2' align='left'>
            <u>Category</u> : {offerData.o.offer_Category.name}
          </Typography>

          {/* <div className={classes.bnn}>
            <Button size='large' color='primary'>
              <FavoriteIcon />
              Like
            </Button>
            <Button size='large' color='primary'>
              Engage
            </Button>
          </div> */}

          <Divider variant='fullWidth' style={{ marginTop: 40 }} />

          <Container className={classes.cmtsec}>
            <WriteComment eid={user.id} oid={offerData.o.id} />
          </Container>

          <div>
            <Button
              type='submit'
              variant='outlined'
              color='primary'
              onClick={handleGetComments}
            >
              {viewComment ? 'Hide Comments' : 'View Comments'}
            </Button>

            {viewComment && (
              <div style={{ marginLeft: 10, marginTop: 25 }}>
                {commentLoaded ? (
                  commentData.map(item => <Comment key={item.id} data={item} />)
                ) : (
                  <Loading color='primary' size={30} />
                )}
              </div>
            )}
          </div>
        </Container>
      ) : (
        <Loading color='primary' size={50} />
      )}
    </div>
  )
}
