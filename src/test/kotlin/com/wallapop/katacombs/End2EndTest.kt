package com.wallapop.katacombs

import io.restassured.RestAssured
import org.apache.http.HttpStatus
import org.junit.jupiter.api.Test
import org.springframework.boot.test.context.SpringBootTest
import java.util.UUID

@SpringBootTest
class End2EndTest {

    @Test
    fun `should start game`() {
        RestAssured.given()
                .body("{\"user_id\":\"${UUID.randomUUID()}\"}")
                .post("/start")
                .then()
                .statusCode(HttpStatus.SC_OK)
    }

}
