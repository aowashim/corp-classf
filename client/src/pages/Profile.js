import { Container, makeStyles, Toolbar, Typography } from '@material-ui/core'
import SubdirectoryArrowRightIcon from '@material-ui/icons/SubdirectoryArrowRight'
import { useLocation } from 'react-router-dom'
import NavBar from '../components/NavBar'

const data = {
  empId: 123444,
  empName: 'Owashim Akram',
  email: 'aowashim@gmail.com',
  designation: 'Programmer Analyst',
  officeLocation: 'Bangalore',
  pointsGained: 500,
}

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

  return (
    <>
      <NavBar path={pathname} />
      <Toolbar />
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
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Employee Id : <b>{data.empId}</b>
              </Typography>
            </div>
            <div style={{ display: 'flex', padding: 5 }}>
              <div style={{ marginRight: 8, marginTop: 2 }}>
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Name : <b>{data.empName}</b>
              </Typography>
            </div>
            <div style={{ display: 'flex', padding: 5 }}>
              <div style={{ marginRight: 8, marginTop: 2 }}>
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Email : <b>{data.email}</b>
              </Typography>
            </div>
            <div style={{ display: 'flex', padding: 5 }}>
              <div style={{ marginRight: 8, marginTop: 2 }}>
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Designation : <b>{data.designation}</b>
              </Typography>
            </div>
            <div style={{ display: 'flex', padding: 5 }}>
              <div style={{ marginRight: 8, marginTop: 2 }}>
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Office Location : <b>{data.officeLocation}</b>
              </Typography>
            </div>
            <div style={{ display: 'flex', padding: 5 }}>
              <div style={{ marginRight: 8, marginTop: 2 }}>
                <SubdirectoryArrowRightIcon fontSize='small' color='primary' />
              </div>
              <Typography component='div'>
                Points Gained : <b>{data.pointsGained}</b>
              </Typography>
            </div>
          </div>
        </div>
      </Container>
    </>
  )
}

export default Profile
