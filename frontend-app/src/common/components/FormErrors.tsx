interface IFormErrorsComponentProps {
    errors: Array<string>
}

function FormErrorsComponent({
    errors,
}: IFormErrorsComponentProps) {
    return (
        <ul className="app-common-errors">
            {errors.map(error => {
                return (
                    <li className="app-common-errors-item">{error}</li>
                )
            })}
        </ul>
    );
}

export default FormErrorsComponent;