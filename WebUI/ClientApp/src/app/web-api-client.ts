//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.20.0.0 (NJsonSchema v10.9.0.0 (Newtonsoft.Json v13.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming

import { mergeMap as _observableMergeMap, catchError as _observableCatch } from 'rxjs/operators';
import { Observable, throwError as _observableThrow, of as _observableOf } from 'rxjs';
import { Injectable, Inject, Optional, InjectionToken } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpResponseBase } from '@angular/common/http';

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export interface IOidcConfigurationClient {
    getClientRequestParameters(clientId: string): Observable<FileResponse>;
}

@Injectable({
    providedIn: 'root'
})
export class OidcConfigurationClient implements IOidcConfigurationClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getClientRequestParameters(clientId: string): Observable<FileResponse> {
        let url_ = this.baseUrl + "/_configuration/{clientId}";
        if (clientId === undefined || clientId === null)
            throw new Error("The parameter 'clientId' must be defined.");
        url_ = url_.replace("{clientId}", encodeURIComponent("" + clientId));
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/octet-stream"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetClientRequestParameters(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetClientRequestParameters(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<FileResponse>;
                }
            } else
                return _observableThrow(response_) as any as Observable<FileResponse>;
        }));
    }

    protected processGetClientRequestParameters(response: HttpResponseBase): Observable<FileResponse> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            let fileNameMatch = contentDisposition ? /filename\*=(?:(\\?['"])(.*?)\1|(?:[^\s]+'.*?')?([^;\n]*))/g.exec(contentDisposition) : undefined;
            let fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[3] || fileNameMatch[2] : undefined;
            if (fileName) {
                fileName = decodeURIComponent(fileName);
            } else {
                fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
                fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            }
            return _observableOf({ fileName: fileName, data: responseBlob as any, status: status, headers: _headers });
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export interface ITodoItemsClient {
    getTodoItems(pagenumber: number | undefined, pageSize: number | undefined, listId: string | undefined): Observable<PaginatedListOfTodoItem>;
}

@Injectable({
    providedIn: 'root'
})
export class TodoItemsClient implements ITodoItemsClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getTodoItems(pagenumber: number | undefined, pageSize: number | undefined, listId: string | undefined): Observable<PaginatedListOfTodoItem> {
        let url_ = this.baseUrl + "/api/TodoItems/GetTodoItems?";
        if (pagenumber === null)
            throw new Error("The parameter 'pagenumber' cannot be null.");
        else if (pagenumber !== undefined)
            url_ += "pagenumber=" + encodeURIComponent("" + pagenumber) + "&";
        if (pageSize === null)
            throw new Error("The parameter 'pageSize' cannot be null.");
        else if (pageSize !== undefined)
            url_ += "pageSize=" + encodeURIComponent("" + pageSize) + "&";
        if (listId === null)
            throw new Error("The parameter 'listId' cannot be null.");
        else if (listId !== undefined)
            url_ += "listId=" + encodeURIComponent("" + listId) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetTodoItems(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetTodoItems(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<PaginatedListOfTodoItem>;
                }
            } else
                return _observableThrow(response_) as any as Observable<PaginatedListOfTodoItem>;
        }));
    }

    protected processGetTodoItems(response: HttpResponseBase): Observable<PaginatedListOfTodoItem> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = PaginatedListOfTodoItem.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export interface ITodoListClient {
    getTodoList(pageNumber: number | undefined, pageSize: number | undefined): Observable<PaginatedListOfTodoList>;
}

@Injectable({
    providedIn: 'root'
})
export class TodoListClient implements ITodoListClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    getTodoList(pageNumber: number | undefined, pageSize: number | undefined): Observable<PaginatedListOfTodoList> {
        let url_ = this.baseUrl + "/api/TodoList/GetTodoList?";
        if (pageNumber === null)
            throw new Error("The parameter 'pageNumber' cannot be null.");
        else if (pageNumber !== undefined)
            url_ += "pageNumber=" + encodeURIComponent("" + pageNumber) + "&";
        if (pageSize === null)
            throw new Error("The parameter 'pageSize' cannot be null.");
        else if (pageSize !== undefined)
            url_ += "pageSize=" + encodeURIComponent("" + pageSize) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGetTodoList(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGetTodoList(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<PaginatedListOfTodoList>;
                }
            } else
                return _observableThrow(response_) as any as Observable<PaginatedListOfTodoList>;
        }));
    }

    protected processGetTodoList(response: HttpResponseBase): Observable<PaginatedListOfTodoList> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = PaginatedListOfTodoList.fromJS(resultData200);
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export interface IWeatherForecastClient {
    get(): Observable<WeatherForecast[]>;
}

@Injectable({
    providedIn: 'root'
})
export class WeatherForecastClient implements IWeatherForecastClient {
    private http: HttpClient;
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(@Inject(HttpClient) http: HttpClient, @Optional() @Inject(API_BASE_URL) baseUrl?: string) {
        this.http = http;
        this.baseUrl = baseUrl !== undefined && baseUrl !== null ? baseUrl : "";
    }

    get(): Observable<WeatherForecast[]> {
        let url_ = this.baseUrl + "/WeatherForecast";
        url_ = url_.replace(/[?&]$/, "");

        let options_ : any = {
            observe: "response",
            responseType: "blob",
            headers: new HttpHeaders({
                "Accept": "application/json"
            })
        };

        return this.http.request("get", url_, options_).pipe(_observableMergeMap((response_ : any) => {
            return this.processGet(response_);
        })).pipe(_observableCatch((response_: any) => {
            if (response_ instanceof HttpResponseBase) {
                try {
                    return this.processGet(response_ as any);
                } catch (e) {
                    return _observableThrow(e) as any as Observable<WeatherForecast[]>;
                }
            } else
                return _observableThrow(response_) as any as Observable<WeatherForecast[]>;
        }));
    }

    protected processGet(response: HttpResponseBase): Observable<WeatherForecast[]> {
        const status = response.status;
        const responseBlob =
            response instanceof HttpResponse ? response.body :
            (response as any).error instanceof Blob ? (response as any).error : undefined;

        let _headers: any = {}; if (response.headers) { for (let key of response.headers.keys()) { _headers[key] = response.headers.get(key); }}
        if (status === 200) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            if (Array.isArray(resultData200)) {
                result200 = [] as any;
                for (let item of resultData200)
                    result200!.push(WeatherForecast.fromJS(item));
            }
            else {
                result200 = <any>null;
            }
            return _observableOf(result200);
            }));
        } else if (status !== 200 && status !== 204) {
            return blobToText(responseBlob).pipe(_observableMergeMap((_responseText: string) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            }));
        }
        return _observableOf(null as any);
    }
}

export class PaginatedListOfTodoItem implements IPaginatedListOfTodoItem {
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasNextPage?: boolean;
    hasPreviousPage?: boolean;
    items?: TodoItem[];

    constructor(data?: IPaginatedListOfTodoItem) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.pageNumber = _data["pageNumber"];
            this.totalPages = _data["totalPages"];
            this.totalCount = _data["totalCount"];
            this.hasNextPage = _data["hasNextPage"];
            this.hasPreviousPage = _data["hasPreviousPage"];
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(TodoItem.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PaginatedListOfTodoItem {
        data = typeof data === 'object' ? data : {};
        let result = new PaginatedListOfTodoItem();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["pageNumber"] = this.pageNumber;
        data["totalPages"] = this.totalPages;
        data["totalCount"] = this.totalCount;
        data["hasNextPage"] = this.hasNextPage;
        data["hasPreviousPage"] = this.hasPreviousPage;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }
}

export interface IPaginatedListOfTodoItem {
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasNextPage?: boolean;
    hasPreviousPage?: boolean;
    items?: TodoItem[];
}

export class BaseAuditableEntity implements IBaseAuditableEntity {
    createdAt?: Date;
    createdBy?: string | undefined;
    lastModifiedAt?: Date | undefined;
    lastModifiedBy?: string | undefined;

    constructor(data?: IBaseAuditableEntity) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.createdAt = _data["createdAt"] ? new Date(_data["createdAt"].toString()) : <any>undefined;
            this.createdBy = _data["createdBy"];
            this.lastModifiedAt = _data["lastModifiedAt"] ? new Date(_data["lastModifiedAt"].toString()) : <any>undefined;
            this.lastModifiedBy = _data["lastModifiedBy"];
        }
    }

    static fromJS(data: any): BaseAuditableEntity {
        data = typeof data === 'object' ? data : {};
        let result = new BaseAuditableEntity();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["createdAt"] = this.createdAt ? this.createdAt.toISOString() : <any>undefined;
        data["createdBy"] = this.createdBy;
        data["lastModifiedAt"] = this.lastModifiedAt ? this.lastModifiedAt.toISOString() : <any>undefined;
        data["lastModifiedBy"] = this.lastModifiedBy;
        return data;
    }
}

export interface IBaseAuditableEntity {
    createdAt?: Date;
    createdBy?: string | undefined;
    lastModifiedAt?: Date | undefined;
    lastModifiedBy?: string | undefined;
}

export abstract class BaseEntity extends BaseAuditableEntity implements IBaseEntity {
    id?: string;
    domainEvents?: DomainEvents[];

    constructor(data?: IBaseEntity) {
        super(data);
    }

    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
            if (Array.isArray(_data["domainEvents"])) {
                this.domainEvents = [] as any;
                for (let item of _data["domainEvents"])
                    this.domainEvents!.push(DomainEvents.fromJS(item));
            }
        }
    }

    static override fromJS(data: any): BaseEntity {
        data = typeof data === 'object' ? data : {};
        throw new Error("The abstract class 'BaseEntity' cannot be instantiated.");
    }

    override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        if (Array.isArray(this.domainEvents)) {
            data["domainEvents"] = [];
            for (let item of this.domainEvents)
                data["domainEvents"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IBaseEntity extends IBaseAuditableEntity {
    id?: string;
    domainEvents?: DomainEvents[];
}

export class TodoItem extends BaseEntity implements ITodoItem {
    listId?: string | undefined;
    title?: string | undefined;
    notes?: string | undefined;
    priority?: Priority;
    done?: boolean;
    list?: TodoList;

    constructor(data?: ITodoItem) {
        super(data);
    }

    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.listId = _data["listId"];
            this.title = _data["title"];
            this.notes = _data["notes"];
            this.priority = _data["priority"];
            this.done = _data["done"];
            this.list = _data["list"] ? TodoList.fromJS(_data["list"]) : <any>undefined;
        }
    }

    static override fromJS(data: any): TodoItem {
        data = typeof data === 'object' ? data : {};
        let result = new TodoItem();
        result.init(data);
        return result;
    }

    override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["listId"] = this.listId;
        data["title"] = this.title;
        data["notes"] = this.notes;
        data["priority"] = this.priority;
        data["done"] = this.done;
        data["list"] = this.list ? this.list.toJSON() : <any>undefined;
        super.toJSON(data);
        return data;
    }
}

export interface ITodoItem extends IBaseEntity {
    listId?: string | undefined;
    title?: string | undefined;
    notes?: string | undefined;
    priority?: Priority;
    done?: boolean;
    list?: TodoList;
}

export enum Priority {
    Low = 0,
    Medium = 1,
    High = 2,
}

export class TodoList extends BaseEntity implements ITodoList {
    userId?: string;
    title?: string | undefined;
    colour?: Colour;
    user?: UserProfile;
    items?: TodoItem[];

    constructor(data?: ITodoList) {
        super(data);
    }

    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.userId = _data["userId"];
            this.title = _data["title"];
            this.colour = _data["colour"] ? Colour.fromJS(_data["colour"]) : <any>undefined;
            this.user = _data["user"] ? UserProfile.fromJS(_data["user"]) : <any>undefined;
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(TodoItem.fromJS(item));
            }
        }
    }

    static override fromJS(data: any): TodoList {
        data = typeof data === 'object' ? data : {};
        let result = new TodoList();
        result.init(data);
        return result;
    }

    override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["userId"] = this.userId;
        data["title"] = this.title;
        data["colour"] = this.colour ? this.colour.toJSON() : <any>undefined;
        data["user"] = this.user ? this.user.toJSON() : <any>undefined;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface ITodoList extends IBaseEntity {
    userId?: string;
    title?: string | undefined;
    colour?: Colour;
    user?: UserProfile;
    items?: TodoItem[];
}

export abstract class ValueObject implements IValueObject {

    constructor(data?: IValueObject) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
    }

    static fromJS(data: any): ValueObject {
        data = typeof data === 'object' ? data : {};
        throw new Error("The abstract class 'ValueObject' cannot be instantiated.");
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        return data;
    }
}

export interface IValueObject {
}

export class Colour extends ValueObject implements IColour {
    code?: string;

    constructor(data?: IColour) {
        super(data);
    }

    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.code = _data["code"];
        }
    }

    static override fromJS(data: any): Colour {
        data = typeof data === 'object' ? data : {};
        let result = new Colour();
        result.init(data);
        return result;
    }

    override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["code"] = this.code;
        super.toJSON(data);
        return data;
    }
}

export interface IColour extends IValueObject {
    code?: string;
}

export class UserProfile extends BaseEntity implements IUserProfile {
    firstName?: string;
    lastName?: string | undefined;
    gender?: string | undefined;
    dob?: Date | undefined;
    lists?: TodoList[];

    constructor(data?: IUserProfile) {
        super(data);
    }

    override init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.gender = _data["gender"];
            this.dob = _data["dob"] ? new Date(_data["dob"].toString()) : <any>undefined;
            if (Array.isArray(_data["lists"])) {
                this.lists = [] as any;
                for (let item of _data["lists"])
                    this.lists!.push(TodoList.fromJS(item));
            }
        }
    }

    static override fromJS(data: any): UserProfile {
        data = typeof data === 'object' ? data : {};
        let result = new UserProfile();
        result.init(data);
        return result;
    }

    override toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["gender"] = this.gender;
        data["dob"] = this.dob ? this.dob.toISOString() : <any>undefined;
        if (Array.isArray(this.lists)) {
            data["lists"] = [];
            for (let item of this.lists)
                data["lists"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IUserProfile extends IBaseEntity {
    firstName?: string;
    lastName?: string | undefined;
    gender?: string | undefined;
    dob?: Date | undefined;
    lists?: TodoList[];
}

export class DomainEvents implements IDomainEvents {

    constructor(data?: IDomainEvents) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
    }

    static fromJS(data: any): DomainEvents {
        data = typeof data === 'object' ? data : {};
        let result = new DomainEvents();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        return data;
    }
}

export interface IDomainEvents {
}

export class PaginatedListOfTodoList implements IPaginatedListOfTodoList {
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasNextPage?: boolean;
    hasPreviousPage?: boolean;
    items?: TodoList[];

    constructor(data?: IPaginatedListOfTodoList) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.pageNumber = _data["pageNumber"];
            this.totalPages = _data["totalPages"];
            this.totalCount = _data["totalCount"];
            this.hasNextPage = _data["hasNextPage"];
            this.hasPreviousPage = _data["hasPreviousPage"];
            if (Array.isArray(_data["items"])) {
                this.items = [] as any;
                for (let item of _data["items"])
                    this.items!.push(TodoList.fromJS(item));
            }
        }
    }

    static fromJS(data: any): PaginatedListOfTodoList {
        data = typeof data === 'object' ? data : {};
        let result = new PaginatedListOfTodoList();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["pageNumber"] = this.pageNumber;
        data["totalPages"] = this.totalPages;
        data["totalCount"] = this.totalCount;
        data["hasNextPage"] = this.hasNextPage;
        data["hasPreviousPage"] = this.hasPreviousPage;
        if (Array.isArray(this.items)) {
            data["items"] = [];
            for (let item of this.items)
                data["items"].push(item.toJSON());
        }
        return data;
    }
}

export interface IPaginatedListOfTodoList {
    pageNumber?: number;
    totalPages?: number;
    totalCount?: number;
    hasNextPage?: boolean;
    hasPreviousPage?: boolean;
    items?: TodoList[];
}

export class WeatherForecast implements IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    temperatureF?: number;
    summary?: string | undefined;

    constructor(data?: IWeatherForecast) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.date = _data["date"] ? new Date(_data["date"].toString()) : <any>undefined;
            this.temperatureC = _data["temperatureC"];
            this.temperatureF = _data["temperatureF"];
            this.summary = _data["summary"];
        }
    }

    static fromJS(data: any): WeatherForecast {
        data = typeof data === 'object' ? data : {};
        let result = new WeatherForecast();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["date"] = this.date ? formatDate(this.date) : <any>undefined;
        data["temperatureC"] = this.temperatureC;
        data["temperatureF"] = this.temperatureF;
        data["summary"] = this.summary;
        return data;
    }
}

export interface IWeatherForecast {
    date?: Date;
    temperatureC?: number;
    temperatureF?: number;
    summary?: string | undefined;
}

function formatDate(d: Date) {
    return d.getFullYear() + '-' + 
        (d.getMonth() < 9 ? ('0' + (d.getMonth()+1)) : (d.getMonth()+1)) + '-' +
        (d.getDate() < 10 ? ('0' + d.getDate()) : d.getDate());
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}

export class SwaggerException extends Error {
    override message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isSwaggerException = true;

    static isSwaggerException(obj: any): obj is SwaggerException {
        return obj.isSwaggerException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
    if (result !== null && result !== undefined)
        return _observableThrow(result);
    else
        return _observableThrow(new SwaggerException(message, status, response, headers, null));
}

function blobToText(blob: any): Observable<string> {
    return new Observable<string>((observer: any) => {
        if (!blob) {
            observer.next("");
            observer.complete();
        } else {
            let reader = new FileReader();
            reader.onload = event => {
                observer.next((event.target as any).result);
                observer.complete();
            };
            reader.readAsText(blob);
        }
    });
}