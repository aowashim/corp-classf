import React from "react";
import CssBaseline from "@material-ui/core/CssBaseline";
import Typography from "@material-ui/core/Typography";
import { makeStyles } from "@material-ui/core/styles";
import Container from "@material-ui/core/Container";
import { useLocation } from "react-router-dom";
import { TextField } from "@material-ui/core";
import Button from "@material-ui/core/Button";

const useStyles = makeStyles((theme) => ({
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
  ppr: {
    padding: "2rem",
    margin: "1rem",
    border: "none",
  },
  card: {
    height: "100%",
    padding: "0",
    marginTop: "2rem",
  },
}));

export default function WriteComment() {
  const classes = useStyles();

  const { pathname } = useLocation();
  return (
    <React.Fragment>
      <CssBaseline />
      <main>
        <form className={classes.root} noValidate autoComplete="off">
          <TextField
            style={{ margin: 8 }}
            id="outlined-basic"
            label="Write your comments now"
            fullWidth
            variant="outlined"
          />
          <Button
            style={{ margin: 8 }}
            type="submit"
            variant="contained"
            color="primary"
            className={classes.submit}
          >
            Submit
          </Button>
        </form>
      </main>
    </React.Fragment>
  );
}
