import React from 'react'
import { TextField } from '@material-ui/core'
import Button from '@material-ui/core/Button'
import { useFormik } from 'formik'
import { postCommentValidation } from '../helpers/yupValidation'
import { postCommentApi } from '../helpers/API/offer'

export default function WriteComment(props) {
  const formik = useFormik({
    initialValues: {
      comment: '',
    },
    validationSchema: postCommentValidation,
    onSubmit: (values, { resetForm }) => {
      handlePostComment(values.comment, resetForm)
    },
  })

  const handlePostComment = async (val, resetForm) => {
    const res = await postCommentApi(val, props.eid, props.oid)

    if (res.status === 200) {
      resetForm()
      alert('Comment posted successfully...')
    } else {
      alert('An error occurred, please try again...')
    }
  }

  return (
    <div>
      <form onSubmit={formik.handleSubmit}>
        <TextField
          variant='outlined'
          fullWidth
          margin='normal'
          id='comment'
          name='comment'
          label='Write Comment'
          value={formik.values.comment}
          onChange={formik.handleChange}
          error={formik.touched.comment && Boolean(formik.errors.comment)}
          helperText={formik.touched.comment && formik.errors.comment}
        />

        <Button
          style={{ margin: 8 }}
          type='submit'
          variant='contained'
          color='primary'
        >
          Submit
        </Button>
      </form>
    </div>
  )
}
