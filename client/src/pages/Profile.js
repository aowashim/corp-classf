import { Container, makeStyles, Toolbar, Typography } from '@material-ui/core'
import SubdirectoryArrowRightIcon from '@material-ui/icons/SubdirectoryArrowRight'
import { useContext, useEffect, useState } from 'react'
import { Navigate, useLocation } from 'react-router-dom'
import Loading from '../components/Loading'
import NavBar from '../components/NavBar'
import { getEmpProfileApi } from '../helpers/API/employee'
import UserContext from '../store/UserContext'

// const data = {
//   empId: 123444,
//   empName: 'Owashim Akram',
//   email: 'aowashim@gmail.com',
//   designation: 'Programmer Analyst',
//   officeLocation: 'Bangalore',
//   pointsGained: 500,
// }

const useStyles = makeStyles(theme => ({
  profileDetails: {
    marginTop: theme.spacing(3),
    display: 'flex',
    flexDirection: 'column',
    alignItems: 'center',
  },
}))

function Profile() {
  const classes = useStyles()
  const { pathname } = useLocation()
  const { user } = useContext(UserContext)
  const [data, setData] = useState('')
  const [isLoaded, setIsLoaded] = useState(false)

  useEffect(() => {
    handleGetProfile()
  }, [])

  const handleGetProfile = async () => {
    const res = await getEmpProfileApi(user.id)

    if (res.status === 200) {
      setData(res.data)
      setIsLoaded(true)
    } else {
      alert('An error occurred, please try again...')
    }
  }

  return user.id ? (
    <>
      <NavBar path={pathname} />
      <Toolbar />

      {isLoaded ? (
        <Container component='main' maxWidth='sm'>
          <div className={classes.profileDetails}>
            <Typography
              style={{ textDecorationLine: 'underline' }}
              component='h5'
              variant='h5'
            >
              My Profile
            </Typography>
            <div style={{ marginTop: 15 }}>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Employee Id : <b>{data.empId}</b>
                </Typography>
              </div>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Name : <b>{data.empName}</b>
                </Typography>
              </div>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Email : <b>{data.email}</b>
                </Typography>
              </div>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Designation : <b>{data.designation}</b>
                </Typography>
              </div>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Office Location : <b>{data.office_Location}</b>
                </Typography>
              </div>
              <div style={{ display: 'flex', padding: 5 }}>
                <div style={{ marginRight: 8, marginTop: 2 }}>
                  <SubdirectoryArrowRightIcon
                    fontSize='small'
                    color='primary'
                  />
                </div>
                <Typography component='div'>
                  Points Gained : <b>{data.points_Gained}</b>
                </Typography>
              </div>
            </div>
          </div>
        </Container>
      ) : (
        <Loading color='primary' size={50} />
      )}
    </>
  ) : (
    <Navigate to='/signin' />
  )
}

export default Profile
