import React, { useContext, useRef } from 'react'
import { ToastContainer, toast } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import NavBar from '../components/NavBar'
import Button from '@material-ui/core/Button'
import Card from '@material-ui/core/Card'
import CardActions from '@material-ui/core/CardActions'
import CardContent from '@material-ui/core/CardContent'
import Grid from '@material-ui/core/Grid'
import Typography from '@material-ui/core/Typography'
import { makeStyles } from '@material-ui/core/styles'
import Container from '@material-ui/core/Container'
import { Navigate, useLocation, useNavigate } from 'react-router-dom'
import Link from '@material-ui/core/Link'
import DescriptionIcon from '@material-ui/icons/Description'
import { useState, useEffect } from 'react'
import { getAllOfferApi } from '../helpers/API/offer'
import Loading from '../components/Loading'
import {
  FormControl,
  InputLabel,
  Select,
  MenuItem,
  Toolbar,
  Divider,
} from '@material-ui/core'
import UserContext from '../store/UserContext'
import FaceIcon from '@material-ui/icons/Face'
import Pagination from '@material-ui/lab/Pagination'
import { appBackground, appPrimary } from '../helpers/constant'

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
  cardGrid: {
    paddingTop: theme.spacing(4),
    paddingBottom: theme.spacing(2),
  },
  formControl: {
    marginTop: theme.spacing(4),
    marginBottom: theme.spacing(1),
    width: '100%',
  },
  card: {
    // boxShadow: "0px 0px 27px 0px rgba(94,94,94,0.64)",
    height: '100%',
    display: 'flex',
    flexDirection: 'column',
    backgroundColor: '#e9d7fc',
  },
  cardMedia: {
    paddingTop: '56.25%', // 16:9
  },
  cardContent: {
    flexGrow: 1,
  },
  footer: {
    backgroundColor: theme.palette.background.paper,
    padding: theme.spacing(6),
  },
  iconTextCont: { display: 'flex', flexDirection: 'row' },
}))

const dataPerPage = 6

toast.configure()
export default function OfferFeed(props) {
  const classes = useStyles()

  const [isLoaded, setIsLoaded] = useState(false)
  const items = useRef([])
  const data = useRef([])
  const [viewOfferBy, setViewOfferBy] = useState(5)
  const numOfPages = useRef(1)
  const { user } = useContext(UserContext)
  const navigate = useNavigate()
  const [page, setPage] = useState(1)
  const [refresh, setRefresh] = useState(false)

  const { pathname } = useLocation()

  useEffect(() => {
    handleGetOffers()
  }, [viewOfferBy])

  const notifyError = msg =>
    toast.error(msg, { position: toast.POSITION.TOP_CENTER })

  const notifySuccess = msg =>
    toast.success(msg, { position: toast.POSITION.TOP_CENTER, autoClose: 2000 })

  const handleChange = (event, value) => {
    setIsLoaded(false)
    setPage(value)
    // data.current = []
    setSlicedData(value)
  }

  // sets the data to be shown at each page
  const setSlicedData = val => {
    const startIdx = (val - 1) * dataPerPage

    const endIdx =
      val === numOfPages.current ? items.current.length : val * dataPerPage

    const curData = items.current.slice(startIdx, endIdx)

    data.current = curData
    setIsLoaded(true)
  }

  const handleGetOffers = async () => {
    let res

    if (viewOfferBy === 5) {
      res = await getAllOfferApi('offer')
    } else if (viewOfferBy === 6) {
      res = await getAllOfferApi(`getOfferDetailsByEmpID/${user.id}`)
    } else if (viewOfferBy === 8) {
      res = await getAllOfferApi('getOfferByTopLikes')
    } else if (viewOfferBy === 9) {
      res = await getAllOfferApi('getOfferByPostedDate')
    } else if (
      viewOfferBy === 1 ||
      viewOfferBy === 2 ||
      viewOfferBy === 3 ||
      viewOfferBy === 4
    ) {
      res = await getAllOfferApi(`getOfferDetailsByCategory/${viewOfferBy}`)
    }

    if (res.status === 200) {
      data.current = []
      numOfPages.current = Math.ceil(res.data.length / dataPerPage)
      setRefresh(!refresh)
      items.current = res.data
      setPage(1)
      setSlicedData(1)
    } else {
      notifyError('An error occurred, please try again...')
    }
  }

  const handleViewOfferDetails = id => {
    navigate(`/offer/${id}`)
  }

  const handleEditOffer = id => {
    navigate(`/edit/${id}`)
  }

  return user.id ? (
    <>
      <NavBar path={pathname} />
      <Toolbar />
      {isLoaded ? (
        <div>
          <Container maxWidth='md'>
            <FormControl className={classes.formControl}>
              <InputLabel shrink id='offer-select-label'>
                Filter offer
              </InputLabel>
              <Select
                labelId='offer-select-label'
                id='offer-select'
                value={viewOfferBy}
                onChange={e => setViewOfferBy(e.target.value)}
                className={classes.selectEmpty}
              >
                <MenuItem value={5}>All Offers</MenuItem>
                <MenuItem value={6}>My Offers</MenuItem>
                <Divider />

                {/* <MenuItem value={7}>Recently Liked</MenuItem> */}
                <MenuItem value={8}>Top Likes</MenuItem>
                <MenuItem value={9}>Posted Date</MenuItem>
                <Divider />

                <MenuItem value={1}>Electronics</MenuItem>
                <MenuItem value={2}>Home Goods</MenuItem>
                <MenuItem value={3}>Education</MenuItem>
                <MenuItem value={4}>Clothing</MenuItem>
              </Select>
            </FormControl>
          </Container>

          <Container
            component='main'
            className={classes.cardGrid}
            maxWidth='md'
          >
            <Grid container spacing={4}>
              {data.current.map(item => (
                <Grid item key={item.id} xs={12} sm={6}>
                  <Card className={classes.card}>
                    {/* <CardMedia
                    className={classes.cardMedia}
                    image="https://source.unsplash.com/random"
                    title="Image title"
                  /> */}
                    <CardContent className={classes.cardContent}>
                      <Typography
                        gutterBottom
                        noWrap
                        variant='h5'
                        component='h2'
                        style={{
                          color: '#1e1233',
                          textDecorationLine: 'underline',
                        }}
                      >
                        {item.title}
                      </Typography>

                      <div className={classes.iconTextCont}>
                        <DescriptionIcon
                          style={{ marginTop: 2 }}
                          color='#1e1233'
                          fontSize='small'
                        />
                        <Typography
                          gutterBottom
                          noWrap
                          color='textSecondary'
                          variant='body1'
                          style={{ marginLeft: 5 }}
                        >
                          {item.description}
                        </Typography>
                      </div>

                      <div
                        style={{
                          display: 'flex',
                          flexDirection: 'row',
                          marginTop: 10,
                        }}
                      >
                        <FaceIcon color='#1e1233' fontSize='small' />
                        <Typography
                          noWrap
                          color='textSecondary'
                          variant='body2'
                          style={{ marginLeft: 5, marginTop: 1 }}
                        >
                          {item.empName}
                        </Typography>
                      </div>
                    </CardContent>
                    <CardActions>
                      <Button
                        variant='contained'
                        size='small'
                        color='primary'
                        onClick={() => handleViewOfferDetails(item.id)}
                        style={{ marginRight: 10 }}
                      >
                        View
                      </Button>
                      <Button
                        variant='contained'
                        size='small'
                        color='primary'
                        onClick={() => handleEditOffer(item.id)}
                        disabled={viewOfferBy === 6 ? false : true}
                      >
                        Edit
                      </Button>
                    </CardActions>
                  </Card>
                </Grid>
              ))}
            </Grid>

            <div
              style={{
                marginTop: 30,
                display: 'flex',
                justifyContent: 'center',
              }}
            >
              <Pagination
                count={numOfPages.current}
                page={page}
                variant='outlined'
                shape='rounded'
                color='secondary'
                onChange={handleChange}
              />
            </div>
          </Container>
        </div>
      ) : (
        <Loading color='primary' size={50} />
      )}
      {/* Footer */}
      {/* <footer className={classes.footer}>
        <Typography variant='h6' align='center' gutterBottom>
          Footer
        </Typography>
        <Typography
          variant='subtitle1'
          align='center'
          color='textSecondary'
          component='p'
        >
          Something here to give the footer a purpose!
        </Typography>
        <Copyright />
      </footer> */}
      {/* End footer */}
    </>
  ) : (
    <Navigate to='/' />
  )
}
