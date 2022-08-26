import { useState } from "react";
import DeleteProduct from "../CrudRequests/DeleteProduct";
import { Button, Form } from "react-bootstrap";
import { idInput } from "../Types/Types";

const DeleteProductComponent = (): JSX.Element => {
    const [responseStatus, setResponseStatus] = useState<boolean | undefined>(
        undefined
    );

    return (
        <>
            <div>
                <Form
                    onSubmit={async (e) => {
                        e.preventDefault();

                        const target = e.target as typeof e.target & idInput;
                        async function init() {
                            let id: number = Number(target.productId.value);
                            const result = await DeleteProduct(id);
                            setResponseStatus(result);
                        }

                        await init();
                    }}
                >
                    <Form.Group controlId="productId">
                        <Form.Label>
                            <i>Enter product id</i>
                        </Form.Label>
                        <Form.Control></Form.Control>
                    </Form.Group>
                    <Button variant="btn btn-primary active" type="submit">
                        Delete
                    </Button>
                </Form>
                <div>
                    Response:{" "}
                    {responseStatus === undefined
                        ? ""
                        : responseStatus.toString()}
                </div>
            </div>
        </>
    );
};

export default DeleteProductComponent;
