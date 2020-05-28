package com.wallapop.katacombs

import com.fasterxml.jackson.databind.ObjectMapper
import com.wallapop.katacombs.application.Player
import io.restassured.RestAssured
import io.restassured.http.ContentType
import org.apache.http.HttpStatus
import org.junit.jupiter.api.Test
import org.springframework.boot.test.context.SpringBootTest

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
        val createRequest = Player("F71B21F0-96BC-11EA-AB12-0800200C9A66", "Gerard")
        RestAssured.given()
                .contentType(ContentType.JSON)
                .body(ObjectMapper().writeValueAsString(createRequest))
                .post("/katacomb/player")
                .then()
                .statusCode(HttpStatus.SC_CREATED)
    }

}
