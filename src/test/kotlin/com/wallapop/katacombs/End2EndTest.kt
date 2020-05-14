package com.wallapop.katacombs

import io.restassured.RestAssured
import io.restassured.http.ContentType
import org.apache.http.HttpStatus
import org.junit.jupiter.api.Test
import org.springframework.boot.test.context.SpringBootTest
import java.util.UUID

@SpringBootTest(
        webEnvironment = SpringBootTest.WebEnvironment.DEFINED_PORT,
        classes = [KatacombsApplication::class]
               )
class End2EndTest {

    @Test
    fun `should start application`() {
        
    }

    @Test
    fun `should start game`() {
        RestAssured.given()
                .contentType(ContentType.JSON)
                .body(""""{"userId":"${UUID.randomUUID()}"}"""")
                .post("/start")
                .then()
                .statusCode(HttpStatus.SC_CREATED)
    }

}
